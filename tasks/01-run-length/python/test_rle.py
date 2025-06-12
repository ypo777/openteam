import rle, fixtures, pytest

@pytest.mark.parametrize("raw,expected", fixtures.CASES)
def test_encode(raw, expected):
    assert rle.encode(raw) == expected
